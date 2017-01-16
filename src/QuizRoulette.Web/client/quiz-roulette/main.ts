import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { QuizRouletteModule } from './quiz-roulette.module';

const platform = platformBrowserDynamic();

platform.bootstrapModule(QuizRouletteModule);
