import React from "react";
import styles from "./styles/Commands.module.css";
import { useDispatch } from "react-redux";
import {
  startNewGameAsync,
  dealAsync,
  hitAsync,
  standAsync,
} from "../context/game-slice";
import { UnknownAction } from "@reduxjs/toolkit";



const Commands: React.FC = () => {
  const dispatch = useDispatch();

  const handleStartNewGame = () => {
    dispatch(startNewGameAsync() as unknown as UnknownAction);
  };

  const handleDeal = () => {
    dispatch(dealAsync() as unknown as UnknownAction);
  };

  const handleHit = () => {
    dispatch(hitAsync() as unknown as UnknownAction);
  };

  const handleStand = () => {
    dispatch(standAsync() as unknown as UnknownAction);
  };

  function valuetext(value: number, index: number): string {
    throw new Error("Function not implemented.");
  }

  return (
    <div className={styles.commands}>
      <button className={styles.button} onClick={handleDeal}>
        Deal
      </button>
      <button className={styles.button} onClick={handleHit}>
        Hit
      </button>
      <button className={styles.button} onClick={handleStand}>
        Stand
      </button>
    </div>
  );
};

export default Commands;
