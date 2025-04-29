import { View, Text, StyleSheet } from "react-native";
import Header from "@/src/components/header";
import { colors } from "../constants/colors";

export default function Index() {
  return (
    <View style={styles.container}>
      <Header />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: colors.whiteIce,
  },
})