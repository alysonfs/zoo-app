export class ZooModel {
    uuid?: string;
    name: string;
    address?: string;
    guestCount = 0;
    animalCount = 0;

    constructor(name: string, address: string) {
        this.name = name;
        this.address = address;
    }
}