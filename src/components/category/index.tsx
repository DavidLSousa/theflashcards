import { ViewStyle, TextStyle, StyleSheet, Text, TouchableOpacity, View } from "react-native";
import { colors } from "@/src/constants/colors";

type Props = {
  name: string;
  selected: boolean;
  onPress: () => void;
};

export default function Category({ name, selected, onPress }: Props) {
  return (
    <TouchableOpacity style={getContainerStyle(selected)} onPress={onPress}>
      <View style={getCheckboxStyle(selected)} />
      <Text style={styles.label}>{name}</Text>
    </TouchableOpacity>
  );
}

const getContainerStyle = (selected: boolean): ViewStyle => ({
  flexDirection: "row",
  alignItems: "center",
  padding: 12,
  marginBottom: 10,
  backgroundColor: colors.whiteIce,
  borderRadius: 8,
  borderWidth: 2,
  borderColor: selected ? colors.blueDark : colors.platinum,
});

const getCheckboxStyle = (selected: boolean): ViewStyle => ({
  height: 20,
  width: 20,
  marginRight: 12,
  borderWidth: 2,
  borderColor: selected ? colors.blueDark : colors.text,
  backgroundColor: selected ? colors.blueDark : "transparent",
  borderRadius: 4,
});

const styles = StyleSheet.create({
  label: {
    color: colors.text,
    fontSize: 16,
  } as TextStyle,
});
