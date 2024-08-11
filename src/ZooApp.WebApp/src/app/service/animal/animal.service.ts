import { Injectable } from "@angular/core";
import { ApiService } from "../http";

export namespace AnimalService {
    export interface Animal {
        uuid: string;
        name: string;
        species: string;
        dateOfBirth: Date;
    }
    
    export interface AnimalCreate extends Omit<Animal, 'uuid'> {}
}

@Injectable({
    providedIn: 'root'
})
export class AnimalService {
    private apiClient: ApiService;
    
    constructor(){
        this.apiClient = new ApiService();
    }
    
    async getAnimalListByZooId(): Promise<AnimalService.Animal[]>{
        return this.apiClient.get<AnimalService.Animal []>('/Animal/List');
    }
    
    async getAnimal(uuid: string): Promise<AnimalService.Animal>{
        return this.apiClient.get<AnimalService.Animal>('/Animal/' + uuid);
    }
    
    async addAnimal(animal: AnimalService.AnimalCreate): Promise<AnimalService.Animal | void>{
        return this.apiClient.post<AnimalService.Animal>('/Animal/add', animal);
    }
}