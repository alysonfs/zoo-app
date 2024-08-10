import { Injectable } from "@angular/core";
import { environment } from "../../../environments/environment";

@Injectable({
    providedIn: 'root'
})
export class ApiService {
    private baseUrl = environment.api.baseUrl;
    
    constructor(){}

    async get<T>(url: string): Promise<T>{
        return fetch(this.baseUrl + url)
            .then(response => response.json());
    }

    async post<T>(url: string, body: any): Promise<T | void>{
        return fetch(this.baseUrl + url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(body)
        })
        .then(response => {
            if(response.ok){
                return response.json();
            }
            return;
        });
    }
}