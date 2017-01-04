import { Nested } from './testing/nested';

export const Wrapper = Nested;
export const Hello = (name: string) => {
    console.log(`Hello, ${name}!`);
    console.log('Hello, again!');
};
