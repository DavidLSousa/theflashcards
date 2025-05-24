import { useState } from "react";
import { LinearGradient } from "expo-linear-gradient";
import { ScrollView } from "react-native";

import Header from "@/src/components/header";
import Card from "@/src/components/card";
import { colors } from "@/src/constants/colors";
import { styles } from "./styles";
import { useCard } from "../hooks/useCard";

export default function AllCardsPage() {

  const cards = useCard.getState().cards;

  return (
    <LinearGradient
      colors={[colors.blueLazuli, colors.blueMedium]}
      style={styles.container}
    >
      <Header />

      <ScrollView contentContainerStyle={styles.scrollContent}>
        
        {/* <Card showAnswer={showAnswer} setShowAnswer={setShowAnswer} /> */}

        {cards.map((card, index) => (
        <Card
          key={index}
          id={card.id}
        />
      ))}
        
      </ScrollView>
    </LinearGradient>
  );
}