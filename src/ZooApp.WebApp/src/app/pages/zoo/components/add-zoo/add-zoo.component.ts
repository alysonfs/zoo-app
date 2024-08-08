import { Component } from "@angular/core";
import { ZooService } from "../../../../service/zoo.service";
import { ZooModel } from "../../../../model/zoo.model";

@Component({
    selector: 'add-zoo',
    templateUrl: './add-zoo.component.html'
})
export class AddZooComponent {
    name: string = '';
    address: string = '';

    constructor(private zooService: ZooService) {}

    addZoo() {
        const newZoo = new ZooModel(this.name, this.address);
        this.zooService.addZoo(newZoo);
        this.name = '';
        this.address = '';
    }
}