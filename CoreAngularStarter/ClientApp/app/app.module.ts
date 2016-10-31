import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { UniversalModule } from 'angular2-universal';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './components/app/app.component'
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { GalleryComponent } from './components/gallery/gallery.component';

import { GalleryService } from './services/gallery.service';

@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        FormsModule,
        AppRoutingModule
    ],
    declarations: [
        AppComponent,
        FetchDataComponent,
        HomeComponent,
        GalleryComponent
    ],
    providers: [
        GalleryService
    ]
})
export class AppModule {
}
