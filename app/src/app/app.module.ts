import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CatProductoComponent } from './ui/view-models/cat-producto/cat-producto.component';
import { CatProductoGateway } from './domain/models/cat-producto/gateway/cat-producto-gateway';
import { CatProductoApiService } from './infraestructure/driven-adapter/cat-producto/cat-producto-api.service';
import { HttpClientModule } from '@angular/common/http';
import { ConfigService } from './infraestructure/driven-adapter/config.service';

@NgModule({
  declarations: [AppComponent, CatProductoComponent],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule],
  providers: [
    { provide: CatProductoGateway, useClass: CatProductoApiService },
    ConfigService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
