import { ContactModule } from './contact-module.js';
import { PreferencesModule } from './preferences-module.js';

document.addEventListener('DOMContentLoaded', function () {
    const contactForm = document.getElementById('user-details-form');
    const contactFormModule = new ContactModule(contactForm);
    contactFormModule.loadFormData();

    const preferencesForm = document.getElementById('user-preferences-form');
    const preferencesFormModule = new PreferencesModule(preferencesForm);
    preferencesFormModule.loadFormData();
});