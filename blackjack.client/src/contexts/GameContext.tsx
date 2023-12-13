import React, { createContext, useState, useEffect } from "react";
import axios from "axios";

export const GameContext = createContext({
  gameState: {
    playerHand: {
      cards: [],
    },
    dealerHand: {
      cards: [],
    },
    player: {},
  },
  startNewGame: () => {},
  deal: () => {},
  hit: () => {},
  stand: () => {},
});

const GameContextProvider = (props) => {
  const baseUrl = "https://localhost:7147/api/Game";
  const [gameState, setGameState] = useState(null);

  const startNewGame = async () => {
    const response = await axios.post(`${baseUrl}/start-new-game`);
    const data = await response.data;
    setGameState(data);

    console.log("startNewGame: ");
    console.log(data);
  };

  const deal = async () => {
    const response = await axios.post(`${baseUrl}/deal-cards`);
    const data = await response.data;
    setGameState(data);

    console.log("deal: ");
    console.log(data);
  };

  const hit = async () => {
    const response = await axios.post(`${baseUrl}/hit`);
    const data = await response.data;
    setGameState(data);

    console.log("hit: ");
    console.log(data);
  };

  const stand = async () => {
    const response = await axios.post(`${baseUrl}/stand`);
    const data = await response.data;

    console.log("stand: ");
    console.log(data);
  };

  const checkWinner = async () => {
    const response = await axios.post(`${baseUrl}/check-winner`);
    const data = await response.data;

    console.log("checkWinner: ");
    console.log(data);
  };

  useEffect(() => {
    console.log("GameContextProvider mounted");
    return () => {
      console.log("GameContextProvider unmounted");
    };
  }, []);

  useEffect(() => {
    console.log("Updated gameState:", gameState);
  }, [gameState]);

  return (
    <GameContext.Provider value={{ gameState, startNewGame, deal, hit, stand }}>
      {props.children}
    </GameContext.Provider>
  );
};

export default GameContextProvider;
