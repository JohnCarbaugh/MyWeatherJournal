<template>
    <div class="d-flex flex-row flex-grow-1 min-vh-100">

        <!-- Sidebar Navigation (+medium devices) -->
        <aside id="sidebar" class="collaspe d-none d-md-block d-flex flex-column border-end bg-primary">

            <!-- Sidebar Header -->
            <header class="navbar navbar-expand-lg navbar-dark bg-primary shadow-lg px-2 w-100">
                <div>
                    <font-awesome-icon :icon="['fas', 'cloud-sun']" class="text-white me-2"/>
                    <span class="navbar-brand mb-0 d-none d-lg-inline">MyWeatherJournal</span>
                </div>
            </header>

            <!-- Sidebar Nav -->
            <nav class="nav flex-column">
                <RouterLink to="/weather" class="nav-link text-light py-2" active-class="active" aria-label="Go to Weather">
                    <font-awesome-icon :icon="['fas', 'tachometer-alt']" class="me-2"/>
                    <div>Weather</div>
                </RouterLink>
                <RouterLink to="/journal" class="nav-link text-light py-2" active-class="active" aria-label="Go to Journal ">
                    <font-awesome-icon :icon="['fas', 'book']" class="me-2"/>
                    <div>Journal</div>
                </RouterLink>
                <RouterLink to="/community" class="nav-link text-light py-2" active-class="active" aria-label="Go to Community">
                    <font-awesome-icon :icon="['fas', 'users']" class="me-2"/>
                    <div>Community</div>
                </RouterLink>
            </nav>

            <!-- Sidebar Footer -->
            <footer class="text-white text-center py-2 align-self-end">
                <div class="container">
                    <div class="mb-2">
                        <a href="#" class="text-white me-3" aria-label="Open Link to Linked In Profile"><i class="bi bi-linkedin"></i></a>
                        <a href="#" class="text-white me-3" aria-label="Open Link to Github MyWeatherJournal Repository"><i class="bi bi-github"></i></a>
                        <a href="#" class="text-white me-3" aria-label="Open Link to Code Pen"><i class="bi bi-code-slash"></i></a>
                    </div>
                    <div class="small">&copy; {{ year }} <span class="footer-title">MyWeatherJournal</span></div>
                    <div class="small"><span class="footer-description">All rights reserved.</span></div>
                </div>
            </footer>

        </aside>

         <!-- Content Body -->
         <div id="content-body" class="d-flex flex-column flex-grow-1">

            <header class="navbar navbar-expand-lg bg-white shadow-lg px-4">
                <form class="w-25 me-3" role="search">
                    <input type="search" class="form-control" placeholder="Search..." aria-label="Search"/>
                </form>
            </header>

            <!-- Route Content -->
            <main class="flex-grow-1 px-4 py-3 mb-md-0 with-mb-60">
                <router-view />
            </main>

            <!-- Mobile Navigation -->
            <nav id="mobile-nav" class="d-md-none navbar fixed-bottom bg-primary text-light border-top shadow-sm p-0">
                <div class="container-fluid d-flex justify-content-around p-0 h-100">
                    <RouterLink to="/weather" class="nav-link text-center p-0 h-100 flex-third" active-class="active" aria-label="Weather">
                        <font-awesome-icon class="pt-2" :icon="['fas', 'tachometer-alt']" />
                        <div class="small">Weather</div>
                    </RouterLink>
                    <RouterLink to="/journal" class="nav-link text-center p-0 h-100 flex-third" active-class="active" aria-label="Journal">
                        <font-awesome-icon class="pt-2" :icon="['fas', 'book']" />
                        <div class="small">Journal</div>
                    </RouterLink><RouterLink to="/community" class="nav-link text-center p-0 h-100 flex-third" active-class="active" aria-label="Community">
                        <font-awesome-icon class="pt-2" :icon="['fas', 'users']" />
                        <div class="small">Community</div>
                    </RouterLink>
                </div>
            </nav>

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

#sidebar {
    display: flex;
    flex-direction: column;
    width: 225px;
    min-width: 225px;
}

#sidebar header {
    height: var(--lg-header-height);
}

#sidebar header div span {
    font-size: 1.1em;
    font-weight: bold;
}

#sidebar header,
#sidebar nav,
#sidebar footer {
    width: 100%;
}

#sidebar nav {
    flex: 1;
}

#sidebar nav a {
    display: flex;
    justify-content: flex-start;
    align-items: center;
    height: var(--lg-header-height);
    min-height: var(--lg-header-height);
}

#sidebar footer {
    justify-content: center;
    text-align: center;
}

#sidebar .nav-link.active {
    background-color: white;
    color: var(--bs-primary) !important;
}

#sidebar nav .nav-link.active {
    background-color: var(--body-bg);
}

#mobile-nav .nav-link.active {
    background-color: var(--body-bg);
    color: var(--bs-primary);
}

/* Medium Only*/

@media (min-width: 768px) {
    #sidebar {
        display: flex;
    }
}

@media (min-width: 768px) and (max-width: 991px) {

    #sidebar {
        display: flex;
        width: 100px;
        min-width: 100px;
    }

    /* Sidebar Header */
    #sidebar header {
        height: var(--lg-header-height);
        width: 100%;
        font-size: 30px;
        justify-content: center;
    }

    #sidebar header .div svg {
        display: none !important;
    }

    #sidebar header span {
        display: none !important;
    }

    /* Sidebar Nav */
    #sidebar header span {
        display: none !important;
    }

    #sidebar nav {
        width: 100%;
        justify-content: flex-start;
        text-align: center;
    }

    #sidebar nav a {
        display: flex;
        flex-direction: column;
        justify-content: center;
        text-align: center;
        width: 100%;
        height: var(--lg-header-height);
    }

    #sidebar nav a svg {
        font-size: 24px;
        margin: 0px !important;
    }

    #sidebar nav a div {
        font-size: 12px;
    }

    #sidebar footer div .footer-title{
        display: none;
    }
}

#content-body header {
    height: var(--lg-header-height);
}

#mobile-nav {
    height: var(--mobile-nav-height);
    min-height: var(--mobile-nav-height);
}

</style>