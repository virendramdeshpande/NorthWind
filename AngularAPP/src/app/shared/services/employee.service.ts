import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import { ThfDisclaimer } from '@totvs/thf-ui/components/thf-disclaimer/thf-disclaimer.interface';

import { TotvsResponse } from '../interfaces/totvs-response.interface';

import { IEmployee } from '../model/employee.model';

@Injectable()
export class EmployeeService {

    // FIXME: Change to the backend service URL
    private apiUrl = '/employee';

    constructor(private http: HttpClient) { }

    query(filters: ThfDisclaimer[], page = 1, pageSize = 20): Observable<TotvsResponse<IEmployee>> {
        
        let url: string = `${this.apiUrl}?pageSize=${pageSize}&page=${page}`;

        if (filters && filters.length > 0) {

            const urlParams = new Array<String>();

            filters.map(filter => {
                urlParams.push(`${filter.property}=${filter.value}`);
            });

            url = `${url}&${urlParams.join('&')}`;
        }

        return this.http.get<TotvsResponse<IEmployee>>(url);
    }

    getById(id: number): Observable<IEmployee> {
        return this.http.get<IEmployee>(`${this.apiUrl}/${id}`);
    }

    create(model: IEmployee): Observable<IEmployee> {
        return this.http.post<IEmployee>(`${this.apiUrl}`, model);
    }

    update(model: IEmployee): Observable<IEmployee> {
        return this.http.put<IEmployee>(`${this.apiUrl}/${model.id}`, model);
    }

    delete(id: number): Observable<Object> {
        return this.http.delete(`${this.apiUrl}/${id}`);
    }

}
