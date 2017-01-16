import { Component, Input } from '@angular/core';

@Component({
    selector: 'hello-world',
    template: `
        <div>Hello, {{name}}!</div>
        <div>
            <input type="text" [(ngModel)]="name" />
        </div>
    `
})
export class HelloWorldComponent {
    @Input() public name: string = 'world';
}
