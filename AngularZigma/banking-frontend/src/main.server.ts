import 'zone.js/node'; // Zone.js for Node/SSR
import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app';

export default function bootstrap(context: any) {
  return bootstrapApplication(AppComponent, appConfig, context);
}
