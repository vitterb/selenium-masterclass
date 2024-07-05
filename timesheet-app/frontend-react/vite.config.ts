/// <reference types="vitest" />
/// <reference types="vite/client" />
import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react-swc'
import dotenv from 'dotenv'

dotenv.config() // load env vars from .env


// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  test: {
    globals: true,
    environment: 'jsdom',
    setupFiles: './src/test/setup.ts',
    // you might want to disable it, if you don't have tests that rely on CSS
    // since parsing CSS is slow
    css: false,
  },
  define: {
    'import.meta.env.VITE_REACT_APP_AUTH0_DOMAIN': JSON.stringify(process.env.VITE_REACT_APP_AUTH0_DOMAIN),
    'import.meta.env.VITE_REACT_APP_AUTH0_CLIENT_ID': JSON.stringify(process.env.VITE_REACT_APP_AUTH0_CLIENT_ID),
  },
})
