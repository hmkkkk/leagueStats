import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react-swc'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
})

interface ImportMetaEnv {
  readonly VITE_BASEURL: string
}

interface ImportMeta {
  readonly env: ImportMetaEnv
}