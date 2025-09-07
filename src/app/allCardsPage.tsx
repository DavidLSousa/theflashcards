import { LinearGradient } from "expo-linear-gradient";
import { FlatList, StatusBar, View } from "react-native";
import { useEffect, useState } from "react";
import { SafeAreaProvider, useSafeAreaInsets } from "react-native-safe-area-context";

import Card from "@/src/components/card";
import { colors } from "@/src/constants/colors";
import { styles } from "./styles";
import { useCard } from "../hooks/useCard";
import Input from "@/src/components/input";

function AllCardsPageContent() {
  const { top } = useSafeAreaInsets();
  const { cards, fetchCards, fetchCardsByCategory } = useCard();
  const [search, setSearch] = useState("");

  useEffect(() => {
    if (search) {
      fetchCardsByCategory(search);
    } else {
      fetchCards();
    }
  }, [search, fetchCards, fetchCardsByCategory]);

  return (
    <LinearGradient
      colors={[colors.blueLazuli, colors.blueMedium]}
      style={[styles.container, { paddingTop: top }]}
    >
      <StatusBar
        barStyle="light-content"
        backgroundColor={colors.blueLazuli}
      />

      <View style={styles.scrollContent}>
        <Input
          placeholder="Pesquisar por categoria"
          value={search}
          onChangeText={setSearch}
        />
      </View>

      <FlatList
        contentContainerStyle={styles.scrollContent}
        data={cards}
        keyExtractor={(item) => item.id}
        renderItem={({ item }) => <Card id={item.id} />}
      />
    </LinearGradient>
  );
}

export default function AllCardsPage() {
  return (
    <SafeAreaProvider>
      <AllCardsPageContent />
    </SafeAreaProvider>
  );
}
