import { configureStore } from "@reduxjs/toolkit";
import gameReducer from "./game-slice";

export const store = configureStore({
    reducer: {
        game: gameReducer,
    },
    });

export default store;