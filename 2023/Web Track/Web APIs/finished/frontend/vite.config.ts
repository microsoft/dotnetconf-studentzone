import react from "@vitejs/plugin-react";
import { defineConfig, loadEnv } from "vite";

// https://vitejs.dev/config/
export default defineConfig(({ mode }) => {
  const env = loadEnv(mode, process.cwd(), "");
  return {
    plugins: [react()],

    server: {
      proxy: {
        "/api": env.API_URL || "http://localhost:5181",
      },
    },
  };
});
