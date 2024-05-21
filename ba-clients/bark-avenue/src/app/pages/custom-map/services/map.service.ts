import { Injectable, OnInit } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class MapService{
  constructor() { }

  searchPlaces(map: google.maps.Map, center: google.maps.LatLng, radius: number, type: string): Promise<google.maps.places.PlaceResult[]> {
    return new Promise((resolve, reject) => {
      const service = new google.maps.places.PlacesService(map);
      const request: google.maps.places.PlaceSearchRequest = {
        location: center,
        radius: radius,
        type: type,
        keyword: 'pet friendly',
      };

      service.nearbySearch(request, (results, status) => {
        if (status === google.maps.places.PlacesServiceStatus.OK) {
          resolve(results!);
        } else {
          reject(status);
        }
      });
    });
  }
  
}
