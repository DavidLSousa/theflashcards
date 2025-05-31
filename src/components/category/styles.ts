import { colors } from "@/src/constants/colors";
import { ViewStyle, StyleSheet, TextStyle } from "react-native";

export const getContainerStyle = (selected: boolean): ViewStyle => ({
  flexDirection: "row",
  alignItems: "center",
  padding: 12,
  marginBottom: 10,
  backgroundColor: colors.whiteIce,
  borderRadius: 8,
  borderWidth: 2,
  borderColor: selected ? colors.blueDark : colors.platinum,
});

export const getCheckboxStyle = (selected: boolean): ViewStyle => ({
  height: 20,
  width: 20,
  marginRight: 12,
  borderWidth: 2,
  borderColor: selected ? colors.blueDark : colors.text,
  backgroundColor: selected ? colors.blueDark : "transparent",
  borderRadius: 4,
});

export const styles = StyleSheet.create({
  label: {
    color: colors.text,
    fontSize: 16,
  } as TextStyle,
});