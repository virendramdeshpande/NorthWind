import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerComponent } from './shared/components/customer/customer';
import { OrdersComponent } from './shared/components/orders/orders';

const routes: Routes = [
  { path: 'customer', component: CustomerComponent },
    { path: 'orders', component: OrdersComponent }, 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
