import { Text, TouchableOpacity, View } from "react-native";
import { getCheckboxStyle, getContainerStyle, styles } from './styles'

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
