import { createSlice } from '@reduxjs/toolkit';
import axios from 'axios';

export const gameSlice = createSlice({
  name: 'game',
  initialState: {
    gameState: {
      playerHand: {
        cards: [],
      },
      dealerHand: {
        cards: [],
      },
      player: {},
    },
  },
  reducers: {
    setGameState: (state, action) => {
      state.gameState = action.payload;
    },
  },
});

export const { setGameState } = gameSlice.actions;
export const selectGameState = (state) => state.game.gameState;

export const startNewGameAsync = () => async (dispatch) => {
  const baseUrl = "https://localhost:7147/api/Game";
  const response = await axios.post(`${baseUrl}/start-new-game`);
  const data = response.data;
  dispatch(setGameState(data));
  console.log("startNewGame: ");
  console.log(data);
};

export const dealAsync = () => async (dispatch) => {
  const baseUrl = "https://localhost:7147/api/Game";
  const response = await axios.post(`${baseUrl}/deal-cards`);
  const data = response.data;
  dispatch(setGameState(data));
  console.log("deal: ");
  console.log(data);
};

export const hitAsync = () => async (dispatch) => {
  const baseUrl = "https://localhost:7147/api/Game";
  const response = await axios.post(`${baseUrl}/hit`);
  const data = response.data;
  dispatch(setGameState(data));
  console.log("hit: ");
  console.log(data);
};

export const standAsync = () => async (dispatch) => {
  const baseUrl = "https://localhost:7147/api/Game";
  const response = await axios.post(`${baseUrl}/stand`);
  const data = response.data;
  dispatch(setGameState(data));
  console.log("stand: ");
  console.log(data);
};

export const betAsync = () => async (dispatch) => {
  const baseUrl = "https://localhost:7147/api/Game";
  const response = await axios.post(`${baseUrl}/bet`);
  const data = response.data;
  console.log("bet: ");
  console.log(data);
};

export const checkWinnerAsync = () => async (dispatch) => {
  const baseUrl = "https://localhost:7147/api/Game";
  const response = await axios.post(`${baseUrl}/check-winner`);
  const data = response.data;
  console.log("checkWinner: ");
  console.log(data);
};

export default gameSlice.reducer;