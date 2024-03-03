import { FormModule } from './form-module.js';

// A schema used to validate the form data
const validationSchema = {
    'first-name': {
        fn: x => typeof x === 'string' && x.length > 0 && x.length < 25,        // check type and value
        message: 'First name must be have between 1 and 24 characters'
    },
    'age': {
        fn: x => validateAge(x),
        message: 'Age must be a number between 0 and 129'
    },
    'starting-date': {
        fn: x => typeof x === 'string' && new Date(x) > Date.now(),        // or whatever you want
        message: 'Starting date must be in the future'
    },
    'email': {
        fn: x => typeof x === 'string' && /[^@]+@[^.]+\..+/.test(x),
        message: 'Email is not valid'
    }
};

// Too long to write this one in-line
const validateAge = x => {
    try {
        x = parseInt(x);
        return x >= 0 && x < 130;
    }
    catch (e) {
        return false;
    }
}

/* Our custom form class containing our own logic for populating and submitting the form data. */
class ContactModule extends FormModule {

    constructor(formElement) {
        super(formElement,validationSchema);
    }

    loadFormData() {
        console.log('Loading form data in ContactModule');
        // Fetch the user's data from the server
        // fetch('/api/user')
        //     .then(response => response.json())
        //     .then(data => {
        //         this._data = data;       // keys need to match the form element names
        //         this.setFormData();
        //     });

        // or for example
        this._data = {
            'first-name': '',
            'last-name': 'Doe',
            'age': -6,
            'starting-date': '2021-01-01',
            'email': 'doej@example.com',
            'save-info': '1'            // use '1' or 'on' to check the checkbox, undefined to uncheck
        };
        // Make sure to call this to actually set them in the form
        this.setFormData();
    }

    submitForm() {
        console.log('Customized submitForm() in ContactModule');

        // Optionally, validate the data before submitting
        const errors = this.validateFormData();
        // If there are errors, display them in an element we placed inside the form and return
        const errorSummary = this.formElement.querySelector('.error-summary');
        if (errors.length > 0) {
            if (errorSummary) {
                errorSummary.innerHTML = `<p>${errors.map(e => e.message).join('<br>')}</p>`;
                errorSummary.hidden = false;
                errorSummary.classList.add('warning');
            }
            return;
        }
        if (errorSummary) {
            errorSummary.innerHTML = '';
            errorSummary.hidden = true;
            errorSummary.classList.remove('warning');
        }
        // Send a fetch PUT request to /contact
        // fetch('/api/contact', {
        //     method: 'PUT',
        //     headers: {
        //         'Content-Type': 'application/json'
        //     },
        //     body: JSON.stringify(this._data)
        // });

        // Calling this only so we can see something happen in this example
        super.submitForm();
    }
}

export { ContactModule };