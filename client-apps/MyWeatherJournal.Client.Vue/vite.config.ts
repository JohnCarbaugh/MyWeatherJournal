import { fileURLToPath, URL } from 'node:url'

import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import vueDevTools from 'vite-plugin-vue-devtools'
import viteCompression from 'vite-plugin-compression';

// https://vite.dev/config/
export default defineConfig({
  build: {
    minify: 'esbuild'
  },
  plugins: [
    vue(),
    //vueDevTools(),    Hiding this for accessibility score, feel free to add back
    viteCompression()
  ],
  resolve: {
    alias: {
      '@': fileURLToPath(new URL('./src', import.meta.url))
    },
  },
  css: {
    preprocessorOptions: {
      scss: {
        additionalData: `@import "@/assets/_variables.scss";`
      }
    }
  }
})
