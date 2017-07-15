import { platformBrowser } from '@angular/platform-browser';
import { QuizRouletteModuleNgFactory } from '../../aot/client/quiz-roulette/quiz-roulette.module.ngfactory';

platformBrowser().bootstrapModuleFactory(QuizRouletteModuleNgFactory);
