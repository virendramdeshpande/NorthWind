import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { httpResource } from '@angular/common/http';
import { CustomerIdsListResponse } from '../../../core/entities/customerResponse';

declare const $: any;

@Component({
  selector: 'app-customer',
  standalone: true,
  imports: [CommonModule],
  templateUrl: 'customer.html',
  styleUrls: ['customer.css'],
})
export class CustomerComponent implements OnInit {

  ngOnInit(): void {
  $('form').jbvalidator({
        errorMessage: true,
        successClass: true
    });

   
  }


  //CustomerIdsResource = httpResource<CustomerIdsListResponse>(() => {
  //  return `https://localhost:7224/api/Customer/CustomerIDs`;


 //});





}
