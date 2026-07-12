export interface IEmployee {
    id: number;
    name: string;
}

export class Employee implements IEmployee {

    id: number;
    name: string;

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }

    get $id() {
        return this.id;
    }

    get $name() {
        return this.name;
    }

    set $id(id: number) {
        this.id = id;
    }

    set $name(name: string) {
        this.name = name;
    }

    static of(json: any = {}) {
        return new Employee(json);
    }

    static empty() {
        return new Employee();
    }

    static fromJson(json: Array<any> = []) {
        
        let items: Array<IEmployee> = [];

        for (let values of json) {
            items.push(new Employee(values));
        }
        
        return items;
    }

}
