import { validateEarthquakeData } from '../../EarthquakesAndBitcoin/wwwroot/js/validation.js';

// See https://jestjs.io/docs/using-matchers for help on matchers
// and https://jestjs.io/docs/expect

describe('Earthquakes data validation tests', () => {
    test('undefined earthquakes should fail validation', () => {
        expect(validateEarthquakeData(undefined)).toBe(false);
    });

    test('empty earthquakes should pass validation', () => {
        expect(validateEarthquakeData([])).toBe(true);
    });

    test('object earthquakes should fail validation', () => {
        expect(validateEarthquakeData({})).toBe(false);
    });

    test('earthquakes without magnitude, location and eTime should fail validation', () => {
        // arrange
        const earthquakes = [
            { someprop: 4, anotherprop: "something" },
            { someprop: 124, anotherprop: "else" }
        ];
        // act & assert
        expect(validateEarthquakeData(earthquakes)).toBe(false);
    });

    test('earthquakes missing magnitude should fail validation', () => {
        // arrange
        const earthquakes = [
            { location: "56 km S of Whites City, New Mexico", eTime: 1678181804265 },
            { location: "94 km N of Arecibo, Puerto Rico", eTime: 1678168094300 },
            { location: "108 km SSE of Sand Point, Alaska", eTime: 1678194875680 }
        ];
        // act & assert
        expect(validateEarthquakeData(earthquakes)).toBe(false);
    });

    test('earthquakes missing location should fail validation', () => {
        // arrange
        const earthquakes = [
            { magnitude: 3.4, eTime: 1678181804265 },
            { magnitude: 2.3, eTime: 1678168094300 },
            { magnitude: 1.1, eTime: 1678194875680 }
        ];
        // act & assert
        expect(validateEarthquakeData(earthquakes)).toBe(false);
    });

    test('earthquakes with all properties and correct types should pass validation', () => {
        // arrange
        const earthquakes = [
            { magnitude: 3.6, location: "56 km S of Whites City, New Mexico", eTime: 1678181804265 },
            { magnitude: 3.41, location: "94 km N of Arecibo, Puerto Rico", eTime: 1678168094300 },
            { magnitude: 3.4, location: "108 km SSE of Sand Point, Alaska", eTime: 1678194875680 }
        ];
        // act & assert
        expect(validateEarthquakeData(earthquakes)).toBe(true);
    });

    test('earthquakes with all properties but incorrect magnitude type should fail validation', () => {
        // arrange
        const earthquakes = [
            { magnitude: "3.6", location: "56 km S of Whites City, New Mexico", eTime: 1678181804265 },
            { magnitude: "3.41", location: "94 km N of Arecibo, Puerto Rico", eTime: 1678168094300 },
            { magnitude: "3.4", location: "108 km SSE of Sand Point, Alaska", eTime: 1678194875680 }
        ];
        // act & assert
        expect(validateEarthquakeData(earthquakes)).toBe(false);
    });

    test('earthquakes with all properties but incorrect location type should fail validation', () => {
        // arrange
        const earthquakes = [
            { magnitude: 3.6, location: ["56 km S of Whites City, New Mexico"], eTime: 1678181804265 },
            { magnitude: 3.41, location: ["94 km N of Arecibo, Puerto Rico"], eTime: 1678168094300 },
            { magnitude: 3.4, location: ["108 km SSE of Sand Point, Alaska"], eTime: 1678194875680 }
        ];
        // act & assert
        expect(validateEarthquakeData(earthquakes)).toBe(false);
    });

});


