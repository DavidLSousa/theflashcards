import { View, ScrollView, StatusBar } from "react-native";
import { LinearGradient } from "expo-linear-gradient";

import Header from "@/src/components/header";
import NavegationBtn from "@/src/components/navegationBtn";
import { colors } from "@/src/constants/colors";
import { styles } from "./styles";

export default function Index() {
  return (
    <LinearGradient
      colors={[colors.blueLazuli, colors.blueMedium]}
      style={styles.container}
    >
      <StatusBar
        barStyle="light-content"
        backgroundColor={colors.blueLazuli}
      />

      <Header />
      
      <ScrollView contentContainerStyle={styles.scrollContent}>
        

        <View style={styles.buttonsContainer}>
          <NavegationBtn title="Criar Flash Card" page="/newCardPage" />
          <NavegationBtn title="Todos Flash Cards" page="/allCardsPage" />
          <NavegationBtn title="Crie seu Simulado" page="/createSimulatedPage" />
          <NavegationBtn title="Traga ou copie seus cards" page="/ImportExportCardPage" />
        </View>
      </ScrollView>
    </LinearGradient>
  );
}

