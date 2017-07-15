import { Component, Input } from '@angular/core';

@Component({
    selector: 'hello-world',
    styleUrls: ['hello-world.component.less'],
    templateUrl: 'hello-world.component.html'
})
export class HelloWorldComponent {
    @Input() public name: string = 'world';
}
