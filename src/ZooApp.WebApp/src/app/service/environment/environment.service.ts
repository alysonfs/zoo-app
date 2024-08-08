import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EnvironmentService {
  constructor() { }

  getIsProduction(): boolean {
    return environment.production;
  }

  getApiBaseUrl(): string {
    return environment.api.baseUrl;
  }
}
