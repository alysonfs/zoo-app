import { Injectable } from "@angular/core";
import { ZooModel } from "../model/zoo.model";

@Injectable({
    providedIn: 'root'
})
export class ZooService {
    private zoos: ZooModel[] = [];

    addZoo(zoo: ZooModel) {
        this.zoos.push(zoo);
    }

    zooList(): ZooModel[] {
        return this.zoos;
    }   
}