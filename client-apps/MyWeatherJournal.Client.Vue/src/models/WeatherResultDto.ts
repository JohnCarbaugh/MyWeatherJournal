export interface WeatherResultDto {
    city: string;
    state: string;
    countryCode: string;

    timestampUtc: number;
    sunriseUtc: number;
    sunsetUtc: number;

    temperature: number;
    temperatureFeelsLike: number;
    temperatureMin: number;
    temperatureMax: number;

    humidity: number;
    pressure: number;

    description: string;
    icon: string;
    iconUrl: string;

    windSpeed: number;
    windDegree: number;
    windDescription: string;
    windDirection: string;

    latitude: number;
    longitude: number;

    visibilityMetric: number;
    visibilityImperial: number;
}

export function createDefaultWeatherResult(): WeatherResultDto {
    return {
        city: '',
        state: '',
        countryCode: '',

        timestampUtc: 0,
        sunriseUtc: 0,
        sunsetUtc: 0,

        temperature: 0,
        temperatureFeelsLike: 0,
        temperatureMin: 0,
        temperatureMax: 0,

        humidity: 0,
        pressure: 0,

        description: '',
        icon: '',
        iconUrl: '',

        windSpeed: 0,
        windDegree: 0,
        windDescription: '',
        windDirection: '',

        latitude: 0,
        longitude: 0,

        visibilityMetric: 0,
        visibilityImperial: 0
    }
}