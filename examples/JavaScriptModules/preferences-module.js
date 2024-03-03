import { FormModule } from './form-module.js';

/* Minimal example */

class PreferencesModule extends FormModule {

    loadFormData() {
        this._data = {
            'favorite-color': '#A5F37B',
            'favorite-movie': 'Dune: Part Two',
            'mood-value': 43
        };
        this.setFormData();
    }
}

export { PreferencesModule };