<template>

    <div class="d-flex row flex-wrap">

        <!-- Left Column-->
        <div class="col-12 col-lg-9 justify-content-around">
            <!-- TODO: City Weather Overview Here-->
             <div class="py-2">
                <div id="city-weather-card" class="card flex-grow-1 bg-white shadow-sm">
                    <div class="card-body">
                        <h5 class="card-title">City Weather</h5>
                        <h6 class="card-subtitle text-muted">City</h6>
                        <p class="card-text py-3">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                        <a href="#" class="card-link">link here</a>
                    </div>
                </div>
             </div>

    
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

<script setup>
</script>

<style scope>
</style>