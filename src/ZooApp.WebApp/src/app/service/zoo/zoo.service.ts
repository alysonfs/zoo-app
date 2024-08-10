import { Injectable } from "@angular/core";
import { ApiService } from "../http";

export namespace ZooService {
    export interface Zoo {
        uuid: string;
        name: string;
        address: string;
        guestCount: number;
        animalCount: number;
    }
    
    export interface ZooCreate extends Omit<Zoo, 'uuid' | 'guestCount' | 'animalCount'> {}
}

@Injectable({
    providedIn: 'root',
})
export class ZooService {
    private apiClient: ApiService;

    constructor(){
        this.apiClient = new ApiService();
    }

    async getZooList(): Promise<ZooService.Zoo[]>{
        return this.apiClient.get<ZooService.Zoo []>('/Zoo/List');
    }

    async getZoo(uuid: string): Promise<ZooService.Zoo>{
        return this.apiClient.get<ZooService.Zoo>('/Zoo/' + uuid);
    }

    async addZoo(zoo: ZooService.ZooCreate): Promise<ZooService.Zoo | void>{
        return this.apiClient.post<ZooService.Zoo>('/Zoo/add', zoo);
    }
}

 
