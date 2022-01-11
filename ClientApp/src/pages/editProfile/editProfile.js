import "./editProfile.css";
export default function EditProfile(){
    return (
        <div class="edit">
            <div class="editBox">
                <label>Name</label>
                <input type="text" />
                <label>Phone Number</label>
                <input type="number" />
                <label>E-mail</label>
                <input type="text" />
                <button type="submit">Update</button>
            </div>
        </div>
    )
}