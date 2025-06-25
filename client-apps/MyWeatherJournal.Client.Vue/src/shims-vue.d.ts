// TypeScript does not know about .vue files, so we provide this shim to fallback on for unknown types.
// TypeScript is opinionated and wants to know the types is working with. This is a manual fallback declaration for 'vue' files. 
declare module '*.vue' {
    import { DefineComponent } from "vue";
    const component: DefineComponent<{}, {}, any>
    export default component
}