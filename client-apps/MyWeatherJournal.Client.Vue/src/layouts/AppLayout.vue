<template>
    <div class="d-flex flex-row flex-grow-1 min-vh-100">

        <!-- Sidebar -->            <!-- TODO: Remove inline styles when possible-->
        <aside id="sidebar-menu" class="collaspe d-flex flex-column border-end bg-primary" style="width: 225px">
            <!-- Header -->
            <header class="navbar navbar-expand-lg navbar-dark bg-primary shadow-lg px-2">
                <font-awesome-icon :icon="['fas', 'cloud-sun']" class="text-white me-2"/><span class="navbar-brand mb-0 h1">MyWeatherJournal</span>
            </header>
            <!-- Nav -->
            <nav class="nav flex-column">
                <RouterLink to="/dashboard" class="nav-link text-light py-3" aria-label="Go to Dashboard"><font-awesome-icon :icon="['fas', 'tachometer-alt']" class="me-2"/>Dashboard</RouterLink>
                <RouterLink to="/journal" class="nav-link text-light py-3" aria-label="Go to Journal "><font-awesome-icon :icon="['fas', 'book']" class="me-2"/>Journal</RouterLink>
                <RouterLink to="/community" class="nav-link text-light py-3" aria-label="Go to Community"><font-awesome-icon :icon="['fas', 'users']" class="me-2"/>Community</RouterLink>
            </nav>
            <!-- Footer -->
             <div class="mt-auto">
                <footer class="text-white text-center py-2 align-self-end">
                    <div class="container">
                        <div class="mb-2">
                            <a href="#" class="text-white me-3" aria-label="Open Link to Linked In Profile"><i class="bi bi-linkedin"></i></a>
                            <a href="#" class="text-white me-3" aria-label="Open Link to Github MyWeatherJournal Repository"><i class="bi bi-github"></i></a>
                            <a href="#" class="text-white me-3" aria-label="Open Link to Code Pen"><i class="bi bi-code-slash"></i></a>
                        </div>
                        <div class="small">&copy; {{ year }} MyWeatherJournal.</div>
                        <div class="small">All rights reserved.</div>
                    </div>
                </footer>
             </div>
        </aside>

         <!-- Body -->
         <div class="d-flex flex-column flex-grow-1">
            <header class="navbar navbar-expand-lg bg-white shadow-lg px-4">
                <form class="w-25 me-3" role="search">
                    <input type="search" class="form-control" placeholder="Search..." aria-label="Search"/>
                </form>
            </header>
            <!-- Main Content -->
            <main class="flex-grow-1 px-4 py-3" styles="min-height: 0;">
                <router-view />
            </main>
        </div>
    </div>
</template>

<script setup>
import { RouterLink } from 'vue-router'
import { ref } from 'vue'

const isSidebarCollapsed = ref(false);
const year = new Date().getFullYear();
</script>

<style scoped>

</style>