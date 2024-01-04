import React from "react";
import { useState } from "react";
import styles from "./styles/Commands.module.css";
import { useDispatch, useSelector } from "react-redux";
import { selectGameState } from "../context/game-slice";
import { dealAsync, hitAsync, standAsync } from "../context/game-slice";
import { UnknownAction } from "@reduxjs/toolkit";

const Commands: React.FC = () => {
  const [inputValue, setInputValue] = useState();
  const dispatch = useDispatch();
  const gameState = useSelector(selectGameState);

  const handleDeal = () => {
    dispatch(dealAsync() as unknown as UnknownAction);
  };

  const handleHit = () => {
    dispatch(hitAsync() as unknown as UnknownAction);
  };

  const handleStand = () => {
    dispatch(standAsync() as unknown as UnknownAction);
  };

  const handleInputChange = (e) => {
    setInputValue(e.target.value);
  };

  return (
    <div className={styles.commands}>
      <div className={styles.bet}>
        <div className={styles.amountContainer}>
          <div className={styles.amountBox}>
            <p className={styles.balanceText}>Balance:</p>
            <p className={styles.amount}>
              {gameState.player && <div>{gameState.player.balance}</div>}
            </p>
          </div>
        </div>
        <input
          type="number"
          max={gameState.player.balance}
          min={10}
          className={styles.input}
          onChange={handleInputChange}
          value={inputValue}
        />
        <button className={styles.button} onClick={handleDeal}>
          Bet
        </button>
      </div>
      <div className={styles.hitstand}>
        <button className={styles.button} onClick={handleHit}>
          Hit
        </button>
        <button className={styles.button} onClick={handleStand}>
          Stand
        </button>
      </div>
    </div>
  );
};

export default Commands;
