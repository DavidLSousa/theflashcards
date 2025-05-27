import { LinearGradient } from "expo-linear-gradient";
import { FlatList, StatusBar, SafeAreaView } from "react-native";
import { useEffect } from "react";

import Header from "@/src/components/header";
import Card from "@/src/components/card";
import { colors } from "@/src/constants/colors";
import { styles } from "./styles"; 
import { useCard } from "../hooks/useCard";

export default function AllCardsPage() {
  const { cards, fetchCards } = useCard();

  useEffect(() => {
    fetchCards();
  }, []);

  return (
    <LinearGradient
      colors={[colors.blueLazuli, colors.blueMedium]}
      style={styles.container}
    >
      <StatusBar
        barStyle="light-content"
        backgroundColor={colors.blueLazuli}
      />

      <SafeAreaView style={{ flex: 1 }}>
        <FlatList
          contentContainerStyle={styles.scrollContent}
          data={cards}
          keyExtractor={(item) => item.id}
          renderItem={({ item }) => (
            <Card id={item.id} />
          )}
        />
      </SafeAreaView>
    </LinearGradient>
  );
}
