import { useState } from "react";
import { LinearGradient } from "expo-linear-gradient";
import { ScrollView } from "react-native";

import Header from "@/src/components/header";
import Card from "@/src/components/card";
import { colors } from "@/src/constants/colors";
import { styles } from "./styles";

export default function AllCardsPage() {
  const [showAnswer, setShowAnswer] = useState(false);

  return (
    <LinearGradient
      colors={[colors.blueLazuli, colors.blueMedium]}
      style={styles.container}
    >
      <Header />

      <ScrollView contentContainerStyle={styles.scrollContent}>
        
        <Card showAnswer={showAnswer} setShowAnswer={setShowAnswer} />
        
      </ScrollView>
    </LinearGradient>
  );
}