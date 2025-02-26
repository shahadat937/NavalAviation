import { Component, OnInit } from '@angular/core';
import { Event, Router, NavigationStart, NavigationEnd } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { PlatformLocation } from '@angular/common';
import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  currentUrl: string;
  constructor(
    public _router: Router,
    location: PlatformLocation,
    private spinner: NgxSpinnerService
  ) {
    this._router.events.subscribe((routerEvent: Event) => {
      if (routerEvent instanceof NavigationStart) {
        this.spinner.show();
        this.currentUrl = routerEvent.url.substring(
          routerEvent.url.lastIndexOf('/') + 1
        );
      }
      if (routerEvent instanceof NavigationEnd) {
        this.spinner.hide();
      }
      window.scrollTo(0, 0);
    });
  }

  ngOnInit() {
    const meta = document.createElement('meta');
    meta.httpEquiv = 'Content-Security-Policy';
    meta.content = `
      default-src 'self'; 
      script-src 'self' 'unsafe-inline'; 
      style-src 'self' 'unsafe-inline' https://fonts.googleapis.com https://www.w3schools.com; 
      font-src 'self' https://fonts.gstatic.com; 
      img-src 'self' data:; 
      connect-src *; 
      frame-src 'none';
    `;
    document.head.appendChild(meta);
  }
}
