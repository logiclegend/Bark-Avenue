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
export class MapComponent implements OnInit {
  zoom = 12;
  center = {lat: 49.8382600, lng: 24.0232400}
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
  places:any = []
   
  
  constructor(private mapService: MapService){}
  ngOnInit(): void {
  }

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


  searchPetFriendlyPlaces(type: string, icon: string) {
    let center = new google.maps.LatLng(49.8382600, 24.0232400);
    this.mapService.searchPlaces(this.map.googleMap!, center, 10000 ,type)
      .then(results => {
        this.clearMarkers();
        results.forEach(result => {
          const marker = new google.maps.Marker({
            position: result.geometry?.location,
            map: this.map.googleMap!,
            icon: icon,
            title: result.name,
            animation: google.maps.Animation.DROP,
          });
          this.markers.push(marker);
          this.places.push(result);
        });
      })
      .catch(error => {
        console.error('Error fetching places:', error);
      });
  }

  clearMarkers() {
    this.markers.forEach((marker: google.maps.Marker) => marker.setMap(null));
    this.markers = [];
  }
  
  

  

}
