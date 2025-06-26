<template>

    <div class="py-2">
        <div id="city-weather-card" class="card flex-grow-1 bg-white shadow-sm">
            <div class="card-body d-flex justify-content-between">
                <div id="city-weather-details" class="p-2">
                    <h6 class="card-subtitle text-muted py-1">{{ formatTimeStamp(wr.timestampUtc) }}</h6>
                    <h5 class="card-title py-1" v-if="wr.city">{{ wr.city }}<span v-if="wr.state">,</span> {{ wr.state }}</h5>
                    <div class="d-flex justify-content-start align-items-center"><img id="weather-img" v-if="wr.iconUrl" :src="wr.iconUrl"/><h2 class="card-title py-1">{{ wr.temperature }} °F</h2></div>
                    <p class="card-text"><b>Feels like {{ wr.temperatureFeelsLike }}, {{ wr.description }}. {{ wr.windDescription }}.</b></p>
                    <ul class="weather-items">
                        <li>Wind: {{ wr.windSpeed }}mph {{ wr.windDirection }}</li>
                        <li>Pressure: {{ wr.pressure }}Pa</li>
                        <li>Humidty: {{ wr.humidity }}%</li>
                        <li>Visibility: {{ wr.visibilityImperial }} mi.</li>
                    </ul>
                </div>
                <div id="google-maps-placeholder">
                    <p>Google Maps Here</p>
                </div>
            </div>
        </div>
    </div>

</template>

<script setup lang="ts">
import type { WeatherResultDto } from '../models/WeatherResultDto'

defineProps<{
    wr: WeatherResultDto
}>()


function formatTimeStamp(unixUtc: number): string {
    const date = new Date(unixUtc * 1000) // convert seconds to ms

    const options: Intl.DateTimeFormatOptions = {
        year: 'numeric',
        month: 'short',
        day: 'numeric',
        hour: 'numeric',
        minute: '2-digit',
        hour12: true,
        timeZoneName: 'short'   // "CST", "PDT" etc
    };

    return new Intl.DateTimeFormat(undefined, options).format(date);
}

</script>

<style scope>

#city-weather-card div {
    flex-wrap: wrap-reverse;
}

#city-weather-details {
    min-width: 230px;
}

.weather-items {
    list-style: none;
    border-left: solid 3px #EC6E4C;
    padding: 0px 0px 0px 15px;
}

#weather-img {
    width: 80px;
    height: 80px;
}

#google-maps-placeholder {
    display: flex;
    justify-content: center;
    align-items: center;
    border-radius: 6px;
    background-color: grey;
    height: 275px;
    min-width: 220px;
    flex: 1;
}


@media (min-width: 992px) {
    #google-maps-placeholder {
        min-width: 220px;
        max-width: 650px;
        align-self: center;
    }
}

</style>