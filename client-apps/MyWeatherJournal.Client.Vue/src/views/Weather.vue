<template>

    <div class="d-flex row flex-wrap">

        <!-- Left Column-->
        <div class="col-12 col-lg-9 justify-content-around">

            <CityWeatherCard :wr="cityWeather" />
    
            <!-- TODO: Hourly Forecast Here -->
            <div class="py-2">
                <div id="hourly-forecast-card" class="card flex-grow-1 w-100 bg-white shadow-sm">
                    <div class="card-body">
                        <h5 class="card-title">Hourly Forecast</h5>
                        <h6 class="card-subtitle text-muted">Hourly</h6>
                        <p class="card-text py-3">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                        <a href="#" class="card-link">link here</a>
                    </div>
                </div>
            </div>
        </div>

        <!-- Right Column-->
        <div class="col-12 col-lg-3 flex-grow-1 py-2">
            <!-- TODO: 14-Day Forecast Accordion -->
            <div id="daily-forecast-card" class="card flex-grow-1 shadow-sm bg-white">
                <div class="card-body">
                    <h5 class="card-title">Daily Forecast</h5>
                    <h6 class="card-subtitle text-muted">Daily</h6>
                    <p class="card-text py-3">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                    <button class="btn btn-primary">Primary</button>
                </div>
            </div>
        </div>
    </div>

</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { useRoute } from 'vue-router'

import CityWeatherCard from '../components/CityWeatherCard.vue'
import { createDefaultWeatherResult, type WeatherResultDto } from '../models/WeatherResultDto'

const route = useRoute();
const city = ref('');
const state = ref('');
const cityWeather = ref<WeatherResultDto>(createDefaultWeatherResult());

const baseUrl = import.meta.env.VITE_CURRENT_WEATHER_API_BASE_URL;


// TODO: Implement GeoLocation API
async function getCityByGeoLocation() {
    return 'Jenks'; // todo
}

// TODO: Implement GeoLocation API
async function getStateByGeoLocation() {
    return 'oklahoma'; // todo
}

onMounted(async () => {
    // The functionality depends on the city being set, so await both to ensure everything executes in order
    await initializeCity();
    await fetchCityWeather();
})

async function initializeCity() {

    // We need the city at minimum for the API. If state is not specified, that's fine
    if (route.query.city)
    {
        city.value = route.query.city as string;
        state.value = route.query.state as string || '';
    }
    else
    {
        city.value = await getCityByGeoLocation();
        state.value = await getStateByGeoLocation();
    }
}

async function fetchCityWeather() {

    if (!city.value) return;

    const url = new URL(baseUrl);
    url.searchParams.append('city', city.value);

    if (state.value) {
        url.searchParams.append('state', state.value);
    }

    try
    {
        const response = await fetch(url);

        if (!response.ok) {
            throw new Error(`HTTP ${response.status}`);
        }

        cityWeather.value = await response.json();
    }
    catch(err) 
    {
        console.error('API error:', err);
    }

}

</script>

<style scope>
</style>