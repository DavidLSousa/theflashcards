import { TextInput, TextInputProps, NativeSyntheticEvent, TextInputSelectionChangeEventData } from "react-native";
import { styles } from "./styles";

type Props = TextInputProps & {
  value: string;
  onChangeText: (text: string) => void;
  onSelectionChange?: (e: NativeSyntheticEvent<TextInputSelectionChangeEventData>) => void;
};

export default function Input({ value, onChangeText, onSelectionChange, ...rest }: Props) {
  return (
    <TextInput
      style={rest.multiline ? styles.inputMulti : styles.inputSingle}
      placeholderTextColor="#ccc"
      value={value}
      onChangeText={onChangeText}
      onSelectionChange={onSelectionChange}
      {...rest}
    />
  );
}