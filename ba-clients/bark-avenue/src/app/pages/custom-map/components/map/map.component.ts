import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { GoogleMap } from '@angular/google-maps';
import { MapService } from '../../services/map.service';
import { Observable} from 'rxjs';
import { NgxGpAutocompleteDirective } from '@angular-magic/ngx-gp-autocomplete';
import { animation } from '@angular/animations';
import { placeCredentials } from '../../place.model';


@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.scss']
})
export class MapComponent implements OnInit , AfterViewInit {
  zoom = 12;
  center = {lat: 49.8382600, lng: 24.0232400,}
  options: google.maps.MapOptions = {
    // mapTypeId: 'hybrid',
    disableDoubleClickZoom: true,
    maxZoom: 20,
    minZoom: 12,
    mapId: '70746558b01ddc92'
  }

  placeData: placeCredentials = {
    photo: '',
    name: '',
    phoneNumber: '',
    location: '',
    link: '',
  }

  @ViewChild('ngxPlaces') placesRef: NgxGpAutocompleteDirective | undefined;
  @ViewChild('myMap') map!: GoogleMap;
  // @ViewChild('myMarker') marker:any;
  btnShowSearch = false;
  btnNavWindowOpen = false;
  markers : any = [];
  markersChanged = true;
  
  openNavWindow(){
    if(!this.btnNavWindowOpen){
      document.getElementById('navWindow')?.classList.add("map-nav__nav-window--open");
      this.btnNavWindowOpen = true;
    }
  }

  closeNavWindow(){
    if(this.btnNavWindowOpen){
      document.getElementById('navWindow')?.classList.remove("map-nav__nav-window--open");
      this.btnNavWindowOpen = false;
    }
  }

  showSearch(){
    if(!this.btnShowSearch){
      document.getElementById('showInput')?.classList.add("nav-window__btn-show-input--active");
      document.getElementsByClassName("nav-window__search-input")[0]?.classList.add("nav-window__search-input--open");
      this.btnShowSearch = true
    }
  }
  hideSearch(){
      document.getElementById('showInput')?.classList.remove("nav-window__btn-show-input--active");
      document.getElementsByClassName("nav-window__search-input")[0]?.classList.remove("nav-window__search-input--open");
      this.btnShowSearch = false; 
  }

  showSearhPlace(){
    document.getElementById('placeCard')!.style.display = 'block'
    this.closeNavWindow()
  }
  hidenSearhPlace(){
    document.getElementById('placeCard')!.style.display = 'none'
    this.openNavWindow()
  }

    
  handleAddressChange(place: google.maps.places.PlaceResult) {
      this.markers.splice(0,this.markers.length);
      this.markers.push({
        position: {
          lat: place.geometry?.location?.lat(),
          lng: place.geometry?.location?.lng()
        },
        options: {animation: google.maps.Animation.DROP}
      })
      
      this.placeData.photo = place.photos![0].getUrl()
      this.placeData.name = place.name as string;
      this.placeData.phoneNumber = place.formatted_phone_number as string;
      this.placeData.location = place.vicinity as string;
      this.placeData.link = place.website as string;
      this.showSearhPlace();
      console.log(place);
    }

  

  restaurantsNames = ["Добрий Друг паб Львів Pub Lviv", "Hashtag", "Moment"];
  parksNames = ["Парк Погулянка Львів", "Стрийський Парк ЛЬвів", "Студентський парк Львів"];
  hotelsNames = ["міні-готель Особняк Львів","Готель Динамо","Готель Жорж Львів"]

  searchPlaces(categoty: string){
    this.markers.splice(0,this.markers.length);
    let searchPlaces: string[];
    const placesService = new google.maps.places.PlacesService(this.map.googleMap!);
    if(categoty === 'restaurants'){ searchPlaces = this.restaurantsNames }
    else if (categoty === 'parks'){ searchPlaces = this.parksNames }
    else if (categoty === 'hotels'){ searchPlaces = this.hotelsNames }


    searchPlaces!.forEach(placeName => {
      const request = {
        query: placeName,
        fields: ["name", "geometry"]
      };
      placesService.findPlaceFromQuery(
        request,
        (
          results: google.maps.places.PlaceResult[] | null,
          status: google.maps.places.PlacesServiceStatus
        ) => {
          if (status === google.maps.places.PlacesServiceStatus.OK && results) {
            for (let i = 0; i < results.length; i++) {
              this.markers.push({
                position: {
                  lat: results[i].geometry?.location?.lat(),
                  lng: results[i].geometry?.location?.lng()
                },
                icon: {
                  url: "../../../../../assets/images/icons/park-location.svg",
                  scaledSize: new google.maps.Size(30,45),
                },
                options: {animation: google.maps.Animation.DROP}
              })
            }
          }
        }
      );
    });
  }

  ngOnInit(): void {
  }

  ngAfterViewInit() {
    
  }
  

  

}
