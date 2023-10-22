import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { JwtInterceptor } from './services/jwt.interceptor';
import { ItemsListComponent } from './items-list/items-list.component';
import { ItemCreateComponent } from './item-create/item-create.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ItemsListComponent,
    ItemCreateComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [    {
    provide: HTTP_INTERCEPTORS,
    useClass: JwtInterceptor,
    multi: true,
  },],
  bootstrap: [AppComponent]
})
export class AppModule { }
