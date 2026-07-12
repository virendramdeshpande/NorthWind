import { platformBrowser } from '@angular/platform-browser';
import { AppModule } from './app/app-module';
import { routes } from './app.routes';
import { provideRouter } from '@angular/router';
import { NgModule } from '@angular/core';



platformBrowser().bootstrapModule(AppModule, {
  applicationProviders: [
    provideRouter(routes)
  ]
})
  .catch(err => console.error(err));
