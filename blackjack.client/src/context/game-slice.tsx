import { createSlice } from "@reduxjs/toolkit";
import axios from "axios";

export const gameSlice = createSlice({
  name: "game",
  initialState: {
    gameState: {
      playerHand: {
        cards: [],
      },
      dealerHand: {
        cards: [],
      },
      player: {
        balance: 0,
      },
    },
    winner: {},
  },
  reducers: {
    setGameState: (state, action) => {
      state.gameState = action.payload;
    },
    setWinner: (state, action) => {
      state.winner = action.payload;
    },
  },
});

export const { setGameState, setWinner } = gameSlice.actions;
export const selectGameState = (state) => state.game.gameState;
export const selectWinnerState = (state) => state.game.winner;
const baseUrl = `https://localhost:7147/api/Game`;

export const startNewGameAsync = () => async (dispatch) => {
  const response = await axios.post(`${baseUrl}/start-new-game`);
  const data = response.data;
  dispatch(setGameState(data));
  console.log("startNewGame: ");
  console.log(data);
};

export const dealAsync = () => async (dispatch) => {
  const response = await axios.post(`${baseUrl}/deal-cards`);
  const data = response.data;
  dispatch(setGameState(data));
};

export const hitAsync = () => async (dispatch) => {
  const response = await axios.post(`${baseUrl}/hit`);
  const data = response.data;
  dispatch(setGameState(data));
};

export const standAsync = () => async (dispatch) => {
  const response = await axios.post(`${baseUrl}/stand`);
  const data = response.data;
  dispatch(setGameState(data));
};

export const betAsync = (amount: number) => async () => {
  const response = await axios.post(`${baseUrl}/bet?amount=${amount}`);
  const data = response.data;
  console.log("bet: ");
  console.log(data);
};

export const checkWinnerAsync = () => async (dispatch) => {
  const response = await axios.post(`${baseUrl}/check-winner`);
  const data = response.data;
  dispatch(setWinner(data));
};

export default gameSlice.reducer;
