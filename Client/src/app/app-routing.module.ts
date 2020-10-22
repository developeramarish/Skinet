import { NotFoundComponent } from './core/not-found/not-found.component';
import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { TestErrorComponent } from './core/test-error/test-error/test-error.component';

const routes: Routes = [
  {path: '', component: HomeComponent, data: {breadcrumb: 'Home'}},
  {path: 'shop', loadChildren: () => import('./shop/shop.module').then(m => m.ShopModule), data: {breadcrumb: 'Shop'}},
  {path: 'basket', loadChildren: () => import('./basket/basket.module').then(m => m.BasketModule), data: {breadcrumb: 'Basket'}},
  {path: 'not-found', component: NotFoundComponent, data: {breadcrumb: 'NotFound'}},
  {path: 'server-error', component: ServerErrorComponent, data: {breadcrumb: 'ServerError'}},
  {path: 'test-error', component: TestErrorComponent, data: {breadcrumb: 'TestError'}},
  {path: '**', redirectTo: 'not-found', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
